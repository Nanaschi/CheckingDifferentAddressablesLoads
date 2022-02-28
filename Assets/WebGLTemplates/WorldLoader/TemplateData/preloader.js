const Preloader = {
  _timer: null,
  _index: 0,
  _slideshowStarted: false,
  _progress: 0,
  rootEl: document.querySelector('.Preloader'),
  slidesWrapEl: document.querySelector('.Preloader_slides'),
  slides: [
    'TemplateData/slides/slide1-1.jpg',
    'TemplateData/slides/slide2-1.jpg',
    'TemplateData/slides/slide3-1.jpg'
  ],
  slidesEl: [],
  duration: 7000,
  init() {
    this.rootEl.classList.remove('-hidden');
    this.createSlides();
  },
  createSlides() {
    this.slidesEl = this.slides.map((imageUrl, index) => {
      const slide = document.createElement('div');
      const image = document.createElement('img');
      image.src = imageUrl;
      slide.style = `--animation-duration: ${this.duration}ms`;
      slide.setAttribute('data-index', index);
      slide.classList.add('Preloader_slide');
      slide.append(image);
      return slide;
    });

    this.slidesWrapEl.append(...this.slidesEl);
  },
  setProgress(progress) {
    this._progress = Math.min(Math.max(0, progress), 100);
    this.rootEl.style.setProperty('--progress', this._progress);

    if (this._progress >= 20) {
      this.startSlideshow();
    }

    if (this._progress >= 100) {
      this.stopSlideshow();
    }
  },
  startSlideshow() {
    if (!this._slideshowStarted) {
      this._slideshowStarted = true;
      this.setSlide();
      this.rootEl.classList.add('-slideshow');
    }
  },
  stopSlideshow() {
    if (this._slideshowStarted) {
      if (this._timer) {
        clearTimeout(this._timer);
      }

      setTimeout(() => {
        this._slideshowStarted = false;
        this.rootEl.classList.add('-finished');

        this.rootEl.addEventListener(
          'transitionend',
          e => {
            if (e.target === this.rootEl) {
              this.slidesEl = [];
              this.rootEl.remove();
            }
          },
          { once: true }
        );
      }, 400);
    }
  },
  setSlide() {
    if (this._timer) {
      clearTimeout(this._timer);
    }

    if (this._progress >= 95) {
      return;
    }

    const currentSlide = this.slidesEl[this._index];

    this.slidesEl.forEach(slide => {
      slide.classList.remove('-visible');
    });

    currentSlide.classList.add('-visible');

    this._timer = setTimeout(() => {
      this._index =
        this._index === this.slides.length - 1 ? 0 : this._index + 1;
      this.setSlide();
    }, this.duration);
  }
};

Preloader.init();

// const t = setInterval(() => {
//   if (Preloader._progress >= 100) {
//     clearInterval(t);
//   }

//   Preloader.setProgress(Preloader._progress + 0.5);
// }, 100);
