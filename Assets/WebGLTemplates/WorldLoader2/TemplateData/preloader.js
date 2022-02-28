const Preloader = {
  _progress: 0,
  _loaded: false,
  _searchParams: new URLSearchParams(location.search),
  rootEl: document.querySelector('.Preloader'),
  slideshow: {
    _timer: null,
    _index: 0,
    _started: false,
    duration: 7000,
    slidesEl: [],
    slidesWrapEl: document.querySelector('.Preloader_slides'),
    slides: [
      'TemplateData/slides/slide1-1.jpg',
      'TemplateData/slides/slide2-1.jpg',
      'TemplateData/slides/slide3-1.jpg'
    ]
  },
  video: {
    _canPlay: false,
    _finished: false,
    _skip: false,
    _handlers: {
      canplay: null,
      ended: null,
      skip: null
    },
    el: document.querySelector('.Preloader_video'),
    skipButtonEl: document.querySelector('.Preloader_videoSkip')
  },
  init() {
    this.rootEl.classList.remove('-hidden');
    this.video._skip = Boolean(Number(this._searchParams.get('skip_video')));

    if (this.video._skip) {
      this.createSlides();
    } else {
      this.playVideo();
    }
  },
  destroy() {
    this.rootEl.classList.add('-finished');
    this.rootEl.addEventListener(
      'transitionend',
      e => {
        if (e.target === this.rootEl) {
          this.slideshow.slidesEl = [];
          this.rootEl.remove();
        }
      },
      { once: true }
    );

    if (!this.video._skip) {
      this.video.el.removeEventListener(
        'canplay',
        this.video._handlers.canplay
      );
      this.video.el.removeEventListener('ended', this.video._handlers.ended);
      this.video.skipButtonEl.addEventListener(
        'click',
        this.video._handlers.skip
      );
      window.removeEventListener('keydown', this.video._handlers.skip);
    }
  },
  playVideo() {
    this.video._handlers.canplay = () => {
      this.video._canPlay = true;
      this.video.el.play();
      this.rootEl.classList.add('-video');
    };

    this.video._handlers.ended = () => {
      if (this._loaded) {
        this.video._finished = true;
        this.destroy();
      } else {
        this.rootEl.classList.remove('-video');
        this.video._skip = true;
        this.createSlides();
      }
    };

    this.video._handlers.skip = e => {
      if (!e.keyCode || e.keyCode === 32) {
        this.destroy();
      }
    };

    this.video.el.addEventListener('canplay', this.video._handlers.canplay);
    this.video.el.addEventListener('ended', this.video._handlers.ended);
    this.video.skipButtonEl.addEventListener(
      'click',
      this.video._handlers.skip
    );

    window.addEventListener('keydown', this.video._handlers.skip);
  },
  createSlides() {
    this.slideshow.slidesEl = this.slideshow.slides.map((imageUrl, index) => {
      const slide = document.createElement('div');
      const image = document.createElement('img');
      image.src = imageUrl;
      slide.style = `--animation-duration: ${this.slideshow.duration}ms`;
      slide.setAttribute('data-index', index);
      slide.classList.add('Preloader_slide');
      slide.append(image);
      return slide;
    });

    this.slideshow.slidesWrapEl.append(...this.slideshow.slidesEl);
  },
  setProgress(progress) {
    this._progress = Math.min(Math.max(0, progress), 100);
    this.rootEl.style.setProperty('--progress', this._progress);

    if (this._progress >= 20) {
      if (this.video._skip) {
        this.startSlideshow();
      }
    }

    if (this._progress >= 100) {
      if (this.video._skip) {
        this.stopSlideshow();
      }

      this._loaded = true;
      this.rootEl.classList.add('-loaded');
    }
  },
  startSlideshow() {
    if (!this.slideshow._started) {
      this.slideshow._started = true;
      this.setSlide();
      this.rootEl.classList.add('-slideshow');
    }
  },
  stopSlideshow() {
    if (this.slideshow._started) {
      if (this.slideshow._timer) {
        clearTimeout(this.slideshow._timer);
      }

      setTimeout(() => {
        this.slideshow._started = false;
        this.destroy();
      }, 400);
    }
  },
  setSlide() {
    if (this.slideshow._timer) {
      clearTimeout(this.slideshow._timer);
    }

    if (this._progress >= 95) {
      return;
    }

    const currentSlide = this.slideshow.slidesEl[this.slideshow._index];

    this.slideshow.slidesEl.forEach(slide => {
      slide.classList.remove('-visible');
    });

    currentSlide.classList.add('-visible');

    this.slideshow._timer = setTimeout(() => {
      this.slideshow._index =
        this.slideshow._index === this.slideshow.slides.length - 1
          ? 0
          : this.slideshow._index + 1;
      this.setSlide();
    }, this.slideshow.duration);
  }
};

Preloader.init();

// const t = setInterval(() => {
//   if (Preloader._progress >= 100) {
//     clearInterval(t);
//   }

//   Preloader.setProgress(Preloader._progress + 0.5);
// }, 100);
