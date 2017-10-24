var gulp = require('gulp');
var sass = require('gulp-sass');
var pug  = require('gulp-pug');
var  minifyCSS = require('gulp-minify-css');
var concat = require('gulp-concat');
var htmlmin = require('gulp-htmlmin');
var debug = require('gulp-debug');
var serve = require('gulp-serve');
var browserSync = require('browser-sync');
//var livereload = require('gulp-livereload');
var imagemin = require('gulp-imagemin');

var allPUG = 'source/view/';
var sourcePUG = 'source/view/page/';
var sourceSCSS = 'source/style/';
var sourceJS = 'source/script/';
var sourceIMG = 'source/image/';
var destHTML = 'build/';
var destMINHTML = 'build/html/min/';
var destCSS = 'build/style/';
var destJS = 'build/script/';
var destIMG = 'build/image';


//BROWSER sync
gulp.task('browserSync', function() {
  browserSync({
    server: {
      baseDir: 'build/'
    },
  })
})


//SCSS => CSS
gulp.task('styles', function() {
  return gulp.src(sourceSCSS+'**/*.scss')
    .pipe(sass().on('error', sass.logError))
    .pipe(minifyCSS()) //minify css
    .pipe(gulp.dest('./'+destCSS))
    .pipe(browserSync.reload({
      stream: true
    }));
});

//PUG => HTML
gulp.task('pug', function() {
  return gulp.src(sourcePUG+'**/*.pug')
    .pipe(pug({
      pretty: true
    }))
    .pipe(browserSync.reload({
      stream: true
    }))
    .pipe(gulp.dest('./'+destHTML))
    //.pipe(livereload({start: true}))
});

//MINIFY HTML
gulp.task('minifyHTML', function() {
  return  gulp.src(sourcePUG+'*.html')
    .pipe(browserSync.reload({
      stream: true
    }))
    .pipe(htmlmin({
      collapseWhitespace: true
    }))
    .pipe(gulp.dest('./'+destMINHTML))
}); 

//EXPORT JS FILES
gulp.task('exportJS',function(){
  return gulp.src(sourceJS+'**/*.js')
    //.pipe(concat('all.js')) //uglify
    .pipe(gulp.dest('./'+destJS))
});

//EXPORT IMG FILES
gulp.task('exportIMG',function(){
  return gulp.src(sourceIMG+'**/*')
    .pipe(imagemin())
    .pipe(gulp.dest('./'+destIMG))
});


//WATCH
gulp.task('watch', function () {
  //livereload.listen();
  gulp.watch('./'+sourceSCSS+'**/*.scss', ['styles']);
  gulp.watch('./'+allPUG+'**/*.pug', ['pug']);
  gulp.watch('./'+sourceJS+'**/*.js', ['exportJS']);
});


//BUILD
gulp.task('build', ['styles', 'pug']);

//DEFAULT
gulp.task('default', ['build']);

//MINIFY
gulp.task('minify', ['minifyHTML', 'exportJS']);

//PROD
gulp.task('prod', ['build', 'minify', 'exportIMG']);

//ALL TASK
gulp.task('launch', ['prod', 'watch'])

//SERVER
gulp.task('serve',['browserSync', 'launch'])