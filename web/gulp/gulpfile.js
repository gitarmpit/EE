const gulp = require('gulp');
const handlebars = require('handlebars');
const concat = require('gulp-concat');
const uglify = require('gulp-uglify');
const htmlmin = require('gulp-htmlmin');
const wrap = require('gulp-wrap');
const rename = require('gulp-rename');
const cleanCSS = require('gulp-clean-css'); 
const fs = require('fs');
const order = require('gulp-order');


gulp.task('html', async function() {
    const mainHtmlPath = 'src/html/main.html';
    const mainHtml = fs.readFileSync(mainHtmlPath, 'utf8');

    const formsFolderPath = 'src/html/';
    const formFiles = fs.readdirSync(formsFolderPath)
                                .filter(file => file.endsWith('.html'))
                                .filter(file => file !== 'main.html' && file !== 'li.html'); 
    let formsHtml = '';
    formFiles.forEach(file => {
        const filePath = formsFolderPath + file;
        formsHtml += fs.readFileSync(filePath, 'utf8');
    });

    const liHtml = fs.readFileSync('src/html/li.html', 'utf8');

    const template = handlebars.compile(mainHtml);

    const context = {
        forms: formsHtml,
	li: liHtml
    };

    const result = template(context);
    fs.writeFileSync('src/html/index.html', result);
});

gulp.task('minify', () => {
  return gulp.src('src/html/index.html')
    .pipe(htmlmin({ collapseWhitespace: true }))
    .pipe(gulp.dest('dist'));
});

gulp.task('scripts', function() {
    return gulp.src('src/js/*.js')
        .pipe(order([
            'ee-calc.js',
	    'ee-calc-conversions.js',
            'ee-calc-field.js' 
        ]))
        .pipe(concat('bundle.js'))
        .pipe(gulp.dest('dist/'))
        .pipe(rename('bundle.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest('dist/'));
});

gulp.task('styles', function() {
    return gulp.src('src/css/*.css')
        .pipe(order([
            'pc.css',
            'mobile.css' 
        ]))
        .pipe(concat('styles.css'))
        .pipe(cleanCSS())
        .pipe(rename('styles.min.css'))
        .pipe(gulp.dest('dist/'));
});

gulp.task('default', gulp.parallel('html', 'minify', 'scripts', 'styles'));
