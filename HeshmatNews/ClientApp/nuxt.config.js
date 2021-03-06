export default {
  // Global page headers: https://go.nuxtjs.dev/config-head
  head: {
    title: 'حشمت نیوز',
    htmlAttrs: {
      lang: 'en'
    },
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: '' }
    ],
    link: [
      { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' },
      {
        rel: 'stylesheet',
        type: 'text/css',
        href:
          'https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css'
      },
      {
        rel: 'stylesheet',
        type: 'text/css',
        href:
          'https://unpkg.com/vue-multiselect@2.1.0/dist/vue-multiselect.min.css'
      }
    ],
    script: [
      {
        src:
          'https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js'
      },
      { src: 'https://code.jquery.com/jquery-3.3.1.slim.min.js' },
      {
        src:
          'https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js'
      },

      {
        src:
          'https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js'
      },
      {
        src:
          'https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.min.js'
      },
      {
        src:
          'https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.bundle.min.js'
      },
      {
        src: '//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js'
      },
      {
        src: '//code.jquery.com/jquery-1.11.1.min.js'
      },
      {
        src: '~/assets/JS/main.js'
      },
      { src: '~/assets/JS/moment.js' },
      { src: '~/assets/JS/bootstrap-datetimepicker.js' }
    ]
  },

  // Global CSS: https://go.nuxtjs.dev/config-css
  css: [],

  // Plugins to run before rendering page: https://go.nuxtjs.dev/config-plugins
  plugins: [
    '~/assets/css/style.css',
    '~/components/Components.js',
    { src: '~/plugins/vue-good-table', ssr: false }

    //   "~/assets/css/mobile.css",
  ],

  // Auto import components: https://go.nuxtjs.dev/config-components
  components: true,

  // Modules for dev and build (recommended): https://go.nuxtjs.dev/config-modules
  buildModules: [],

  // Modules: https://go.nuxtjs.dev/config-modules
  modules: [
    // https://go.nuxtjs.dev/bootstrap
    '@nuxtjs/proxy',
    'bootstrap-vue/nuxt',
    '@nuxtjs/toast'
  ],
  toast: {
    position: 'top-center',
    register: [
      // Register custom toasts
      {
        name: 'my-error',
        message: 'Oops...Something went wrong',
        options: {
          type: 'error'
        }
      }
    ]
  },
  server: {
    port: 8080, // default: 3000
    //host: '0.0.0.0', // default: localhost,
    timing: false
  },
  proxy: {
    '/api': {
      target: 'http://localhost:5000'
    }
  },
  // Build Configuration: https://go.nuxtjs.dev/config-build
  build: {
    transpile: ['vee-validate/dist/rules']
  }
};
