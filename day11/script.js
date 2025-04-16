var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g = Object.create((typeof Iterator === "function" ? Iterator : Object).prototype);
    return g.next = verb(0), g["throw"] = verb(1), g["return"] = verb(2), typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (g && (g = 0, op[0] && (_ = 0)), _) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
var Movie = /** @class */ (function () {
    function Movie(poster_path, vote_average, release_date, title, overview) {
        this.poster_path = poster_path;
        this.vote_average = vote_average;
        this.release_date = release_date;
        this.title = title;
        this.overview = overview;
    }
    return Movie;
}());
var MainApp = /** @class */ (function () {
    function MainApp() {
        this.MovieInfo = [];
        this.Index = 0;
        this.fetchMovies();
        this.setupScrollButtons();
        //.search();
    }
    MainApp.prototype.setupScrollButtons = function () {
        var _this = this;
        var leftBtn = document.querySelector(".previous");
        var rightBtn = document.querySelector(".next");
        leftBtn.addEventListener("click", function () { return _this.scrollLeft(); });
        rightBtn.addEventListener("click", function () { return _this.scrollRight(); });
    };
    MainApp.prototype.scrollLeft = function () {
        if (this.Index > 0) {
            this.Index--;
            this.updateMovieDetails(this.MovieInfo[this.Index]);
            this.displayMovies();
        }
    };
    MainApp.prototype.scrollRight = function () {
        if (this.Index < this.MovieInfo.length - 1) {
            this.Index++;
            this.updateMovieDetails(this.MovieInfo[this.Index]);
            this.displayMovies();
        }
    };
    MainApp.prototype.fetchMovies = function () {
        return __awaiter(this, arguments, void 0, function (query) {
            var response, data, error_1;
            if (query === void 0) { query = "spiderman"; }
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        _a.trys.push([0, 3, , 4]);
                        return [4 /*yield*/, fetch("https://api.themoviedb.org/3/search/movie?api_key=21d6601622ce880a80939f3c1823ce8e&query=spiderman")];
                    case 1:
                        response = _a.sent();
                        return [4 /*yield*/, response.json()];
                    case 2:
                        data = _a.sent();
                        this.MovieInfo = data.results.map(function (item) {
                            return new Movie(item.poster_path, item.vote_average, item.release_date, item.title, item.overview);
                        });
                        this.displayMovies();
                        if (this.MovieInfo.length > 0) {
                            this.updateMovieDetails(this.MovieInfo[0]);
                        }
                        return [3 /*break*/, 4];
                    case 3:
                        error_1 = _a.sent();
                        console.error("Error fetching movies:", error_1);
                        return [3 /*break*/, 4];
                    case 4: return [2 /*return*/];
                }
            });
        });
    };
    MainApp.prototype.displayMovies = function () {
        var _this = this;
        var list_movies = document.querySelector("#movies");
        if (list_movies) {
            list_movies.innerHTML = "";
            this.MovieInfo.forEach(function (movie, index) {
                if (!movie.poster_path)
                    return;
                var divv = document.createElement("div");
                divv.className = "movie-card";
                if (index === _this.Index)
                    divv.classList.add("active");
                divv.innerHTML = "<img src=\"https://image.tmdb.org/t/p/w500".concat(movie.poster_path, "\" alt=\"").concat(movie.title, "\" />");
                divv.addEventListener("click", function (e) {
                    e.preventDefault();
                    _this.Index = index;
                    _this.updateMovieDetails(movie);
                    _this.displayMovies();
                });
                list_movies.appendChild(divv);
            });
        }
        else {
            console.error("Error: 'movies' container not found.");
        }
    };
    MainApp.prototype.setDescription = function (str) {
        var _this = this;
        var maxLength = 150;
        var description = document.querySelector("#description");
        if (!description)
            return;
        if (str.length <= maxLength) {
            description.textContent = str;
            return;
        }
        var shortText = str.substring(0, maxLength);
        description.innerHTML = "\n        ".concat(shortText, "... <a href=\"#\" id=\"see-more\" style=\"color: goldenrod;\">See more</a>\n      ");
        setTimeout(function () {
            var seeMoreLink = document.getElementById("see-more");
            if (seeMoreLink) {
                seeMoreLink.addEventListener("click", function (e) {
                    e.preventDefault();
                    description.innerHTML = "\n              ".concat(str, " <a href=\"#\" id=\"see-less\" style=\"color: goldenrod;\">See less</a>\n            ");
                    setTimeout(function () {
                        var seeLessLink = document.getElementById("see-less");
                        if (seeLessLink) {
                            seeLessLink.addEventListener("click", function (e) {
                                e.preventDefault();
                                _this.setDescription(str);
                            });
                        }
                    }, 0);
                });
            }
        }, 0);
    };
    MainApp.prototype.updateMovieDetails = function (movie) {
        var background = document.querySelector(".background");
        var titleElement = document.getElementById("The-title");
        var imdbYellow = document.querySelector(".IMDb-Yellow");
        var imdb = document.querySelector(".IMDb");
        var description = document.getElementById("description");
        if (movie.poster_path) {
            background.style.backgroundImage = "\n          linear-gradient(to right, rgba(0, 0, 0, 0.95), rgba(0, 0, 0, 0.3)),\n          url(https://image.tmdb.org/t/p/original".concat(movie.poster_path, ")");
        }
        titleElement.textContent = movie.title;
        imdbYellow.textContent = "IMDb";
        imdb.textContent = " ".concat(movie.vote_average);
        //description.textContent = movie.overview;
        this.setDescription(movie.overview);
        //call set_description
    };
    return MainApp;
}());
window.addEventListener("DOMContentLoaded", function () {
    new MainApp();
});
