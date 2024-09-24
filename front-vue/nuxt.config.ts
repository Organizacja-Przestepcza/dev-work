// https://nuxt.com/docs/api/configuration/nuxt-config
import Aura from "@primevue/themes/aura";

export default defineNuxtConfig({
  runtimeConfig: {
    public: {
     ROOT_API: 'http://localhost:5151/api'
    }
    
  },
  
  modules: ["@primevue/nuxt-module", "@nuxtjs/tailwindcss", "@nuxt/icon", "nuxt-viewport",],

  primevue: {
    options: {
      theme: {
        preset: Aura,
      },
    },
  },
  compatibilityDate: "2024-04-03",
  devtools: { enabled: true },
  
});