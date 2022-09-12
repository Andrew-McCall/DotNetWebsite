/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [ 
    './Pages/**/*.cshtml',
    './Views/**/*.cshtml',
    './Shared/**/*.cshtml',
  ],
  plugins: [require("postcss"), require("autoprefixer")]
}
