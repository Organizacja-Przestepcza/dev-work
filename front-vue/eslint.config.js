import globals from "globals";
import pluginJs from "@eslint/js";
import tseslint from "@typescript-eslint/eslint-plugin";
import tsParser from "@typescript-eslint/parser";
import pluginVue from "eslint-plugin-vue";
import eslintPluginPrettier from "eslint-plugin-prettier";
import prettierConfig from "eslint-config-prettier";

export default [
  // Pliki, które będą brane pod uwagę
  { files: ["**/*.{js,mjs,cjs,ts,vue}"] },

  // Ustawienia globalne
  { languageOptions: { globals: globals.browser } },

  // Konfiguracje z @eslint/js (podstawowe zasady JavaScript)
  pluginJs.configs.recommended,

  // Konfiguracje TypeScript
  tseslint.configs.recommended,
  {
    files: ["**/*.ts"],
    languageOptions: {
      parser: tsParser,  // parser dla TypeScript
      parserOptions: {
        project: './tsconfig.json', // wskaż plik tsconfig.json
      }
    }
  },

  // Konfiguracje Vue
  pluginVue.configs["flat/essential"],

  // Specjalne ustawienia dla plików Vue z parserem TypeScript
  {
    files: ["**/*.vue"],
    languageOptions: {
      parserOptions: {
        parser: tsParser // parser dla TypeScript wewnątrz plików .vue
      }
    }
  },

  // Prettier dla integracji z ESLint
  prettierConfig,
  {
    rules: {
      "prettier/prettier": "error", // Ustawienie błędów dla problemów z Prettier
    },
    plugins: {
      prettier: eslintPluginPrettier,
    }
  },

  // Opcjonalnie możesz dodać inne reguły
  {
    rules: {
      "vue/multi-word-component-names": "off",  // Wyłączenie reguły multi-word component names
    }
  }
];
