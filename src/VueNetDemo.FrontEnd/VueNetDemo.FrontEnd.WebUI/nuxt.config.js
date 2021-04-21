export default {
  // Disable server-side rendering: https://go.nuxtjs.dev/ssr-mode
  ssr: false,

  // Global page headers: https://go.nuxtjs.dev/config-head
  head: {
    title: "VueNetDemo.FrontEnd.WebUI",
    meta: [
      { charset: "utf-8" },
      { name: "viewport", content: "width=device-width, initial-scale=1" },
      { hid: "description", name: "description", content: "" }
    ],
    link: [{ rel: "icon", type: "image/x-icon", href: "/favicon.ico" }]
  },

  // Global CSS: https://go.nuxtjs.dev/config-css
  css: [
    'node-snackbar/dist/snackbar.min.css'
  ],

  // Plugins to run before rendering page: https://go.nuxtjs.dev/config-plugins
  plugins: ["~/plugins/snackbar.js"],

  // Auto import components: https://go.nuxtjs.dev/config-components
  components: true,

  // Modules for dev and build (recommended): https://go.nuxtjs.dev/config-modules
  buildModules: [
    // https://go.nuxtjs.dev/typescript
    "@nuxt/typescript-build",

    // https://go.nuxtjs.dev/tailwindcss
    "@nuxtjs/tailwindcss"
  ],

  // Modules: https://go.nuxtjs.dev/config-modules
  modules: [
    // https://go.nuxtjs.dev/axios
    "@nuxtjs/axios",

    // https://go.nuxtjs.dev/pwa
    "@nuxtjs/pwa",

    "@nuxtjs/auth-next"
  ],

  // Axios module configuration: https://go.nuxtjs.dev/config-axios
  axios: {
    baseURL: "http://localhost:38944",

    requestInterceptor: (config, { store }) => {},

    responseInterceptor: (res, ctx) => {}
  },

  // PWA module configuration: https://go.nuxtjs.dev/pwa
  pwa: {
    manifest: {
      lang: "en"
    }
  },

  // Build Configuration: https://go.nuxtjs.dev/config-build
  build: {
    extend(config, ctx) {}
  },

  // router: {
  //   middleware: ['auth']
  // },

  router: {
    middleware: ["auth"]
  },

  auth: {
    scopeKey: "role",

    localStorage: false,

    cookie: {
      prefix: 'auth.',
    },

    redirect: {
      login: "/account/login",
      logout: "/account/login",
      home: "/"
    },

    strategies: {
      local: {
        token: {
          property: "token"
        },

        user: {
          property: "user"
        },

        endpoints: {
          login: { url: "/api/account/login", method: "post" },
          logout: false,
          user: { url: "/api/accountprofile/get", method: "get" },
          refresh: { url: "/api/account/refresh", method: "get" }
        }
      }
    }
  }
};
