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
      grayscale: ["hover", "focus", "group-hover"],
      textColor: ["group-hover"],
      width: ["responsive", "hover", "focus"],
      transitionProperty: ["hover", "group-hover", "focus"],
      transitionDelay: ["hover", "group-hover", "focus"],
      transitionDuration: ["hover", "group-hover", "focus"],
      visibility: ["hover", "group-hover", "focus"],
      transitionTimingFunction: ["hover", "group-hover", "focus"],
    },
  },
  plugins: [require("tailwindcss-named-groups")],
};
