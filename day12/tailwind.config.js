/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["C:/Users/salma/OneDrive/Desktop/hehe/day12/index.html"],
  theme: {
    extend: {
      container: {
        center: true,
      },
      keyframes: {
        sliding: {
          '0%': { transform: 'translateX(0%)' },
          '100%': { transform: 'translateX(-100%)' },
        },
      },
      animation: {
        sliding: 'sliding 60s linear infinite',
      },
    },
  },
  plugins: [],
}
