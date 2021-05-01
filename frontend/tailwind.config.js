module.exports = {
  purge: [],
  darkMode: false, // or 'media' or 'class'
  theme: {
    namedGroups: ["foo", "bar"],
    extend: {},
  },
  variants: {
    extend: {
      display: ["group-hover"],
      grayscale: ['hover', 'focus', 'group-hover'],
      textColor: ['group-hover'],
      width: ["responsive", "hover", "focus"],
    },
  },
  plugins: [
    require("tailwindcss-named-groups"),
  ],
}
