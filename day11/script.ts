class Movie {
    constructor(
      public poster_path: string | null,
      public vote_average: number,
      public release_date: string,
      public title: string,
      public overview: string
    ) {}
  }
  
  class MainApp {
    private MovieInfo: Movie[] = [];
    private Index: number = 0;
  
    constructor() {
      this.fetchMovies();
      this.setupScrollButtons();
      //.search();
      
    }
  
    private setupScrollButtons() {
      const leftBtn = document.querySelector(".previous") as HTMLElement;
      const rightBtn = document.querySelector(".next") as HTMLElement;
  
      leftBtn.addEventListener("click", () => this.scrollLeft());
      rightBtn.addEventListener("click", () => this.scrollRight());
    }
  
    private scrollLeft() {
      if (this.Index > 0) {
        this.Index--;
        this.updateMovieDetails(this.MovieInfo[this.Index]);
        this.displayMovies();
    
      }
    }
    
    private scrollRight() {
      if (this.Index < this.MovieInfo.length - 1) {
        this.Index++;
        this.updateMovieDetails(this.MovieInfo[this.Index]);
        this.displayMovies();
      }
    }
  
    private async fetchMovies(query: string = "spiderman"):Promise<void> {
      try {
        const response = await fetch("https://api.themoviedb.org/3/search/movie?api_key=21d6601622ce880a80939f3c1823ce8e&query=spiderman");
        const data = await response.json();
        this.MovieInfo = data.results.map(
          (item: any) =>
            new Movie(
              item.poster_path,
              item.vote_average,
              item.release_date,
              item.title,
              item.overview
            )
        );
        this.displayMovies();
        if (this.MovieInfo.length > 0) {
          this.updateMovieDetails(this.MovieInfo[0]);
        }
      } catch (error) {
        console.error("Error fetching movies:", error);
      }
    }
  
    private displayMovies() {
      const list_movies = document.querySelector("#movies");
      if (list_movies) {
        list_movies.innerHTML = ""; 
    
        this.MovieInfo.forEach((movie, index) => {
          if (!movie.poster_path) return;
    
          const divv = document.createElement("div");
          divv.className = "movie-card";
          if (index === this.Index) divv.classList.add("active"); 
          
          divv.innerHTML = `<img src="https://image.tmdb.org/t/p/w500${movie.poster_path}" alt="${movie.title}" />`;
    
          divv.addEventListener("click", (e) => {
            e.preventDefault();
            this.Index = index;
            this.updateMovieDetails(movie);
            this.displayMovies();
          });
    
          list_movies.appendChild(divv);
        });
      } else {
        console.error("Error: 'movies' container not found.");
      }
    }

    setDescription(str: string) {
      const maxLength = 150;
      const description = document.querySelector("#description");
      if (!description) return;
    
      if (str.length <= maxLength) {
        description.textContent = str;
        return;
      }
    
      const shortText = str.substring(0, maxLength);
      description.innerHTML = `
        ${shortText}... <a href="#" id="see-more" style="color: goldenrod;">See more</a>
      `;
    
      setTimeout(() => {
        const seeMoreLink = document.getElementById("see-more");
        if (seeMoreLink) {
          seeMoreLink.addEventListener("click", (e) => {
            e.preventDefault();
            description.innerHTML = `
              ${str} <a href="#" id="see-less" style="color: goldenrod;">See less</a>
            `;
            setTimeout(() => {
              const seeLessLink = document.getElementById("see-less");
              if (seeLessLink) {
                seeLessLink.addEventListener("click", (e) => {
                  e.preventDefault();
                  this.setDescription(str); 
                });
              }
            }, 0);
          });
        }
      }, 0);
    }

    private updateMovieDetails(movie: Movie) {
      const background = document.querySelector(".background") as HTMLElement;
      const titleElement = document.getElementById("The-title")!;
      const imdbYellow = document.querySelector(".IMDb-Yellow")!;
      const imdb = document.querySelector(".IMDb")!;
      const description = document.getElementById("description")!;
  
      if (movie.poster_path) {
        background.style.backgroundImage = `
          linear-gradient(to right, rgba(0, 0, 0, 0.95), rgba(0, 0, 0, 0.3)),
          url(https://image.tmdb.org/t/p/original${movie.poster_path})`;
      }
  
      titleElement.textContent = movie.title;
      imdbYellow.textContent = "IMDb";
      imdb.textContent = ` ${movie.vote_average}`;
      //description.textContent = movie.overview;
      this.setDescription(movie.overview);
      //call set_description
    }
  
}
  window.addEventListener("DOMContentLoaded", () => {
    new MainApp();
  });
  