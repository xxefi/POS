import i18n from "i18next";
import { initReactI18next } from "react-i18next";
import commonEN from "./src/locales/en/common.json";
import commonRU from "./src/locales/ru/common.json";
import commonAZ from "./src/locales/az/common.json";
import commonTR from "./src/locales/tr/common.json";
import commonJP from "./src/locales/jp/common.json";
import commonGE from "./src/locales/de/common.json";

const savedLanguage: string = localStorage.getItem("lang") || "en";

i18n.use(initReactI18next).init({
  resources: {
    en: {
      common: commonEN,
    },
    ru: {
      common: commonRU,
    },
    az: {
      common: commonAZ,
    },
    tr: {
      common: commonTR,
    },
    jp: {
      common: commonJP,
    },
    ge: {
      common: commonGE,
    },
  },
  lng: savedLanguage,
  fallbackLng: "en",
  interpolation: {
    escapeValue: false,
  },
});

export default i18n;
