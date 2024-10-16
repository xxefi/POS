import { useState } from "react";
import { useTranslation } from "react-i18next";
import Statistics from "./statistics.tsx";
import Sale from "./sale.tsx";
import Menu from "./menu.tsx";
import Marketing from "./marketing.tsx";
import Staff from "./staff.tsx";
import Access from "./access.tsx";
import Settings from "./settings.tsx";
import Finances from "./finances.tsx";
import { Section } from "../components/interfaces/component.section.ts";
import LanguageSwitcher from "../language.tsx";

const sections: Section[] = [
  { component: Statistics, key: "statistics" },
  { component: Sale, key: "sale" },
  { component: Finances, key: "finances" },
  { component: Menu, key: "menu" },
  { component: Marketing, key: "marketing" },
  { component: Staff, key: "staff" },
  { component: Access, key: "access" },
  { component: Settings, key: "settings" },
];

export default function Navbar() {
  const [openSection, setOpenSection] = useState<string | null>(null);
  const { t } = useTranslation("common");
  const toggleSection = (section: string) => {
    setOpenSection((prev) => (prev === section ? null : section));
  };

  return (
    <div className="relative min-h-screen">
      <div className="fixed top-0 left-0 right-0 p-5 flex justify-between items-center">
        <a href="/" className="text-gray-800 text-decoration-none">
          <span className="text-lg font-semibold">POS</span>
        </a>
        <div className="flex mr-5">
          <LanguageSwitcher />
          <span className="flex items-center ml-2">{t("currentLanguage")}</span>
        </div>
      </div>

      <div
        className="fixed top-0 bottom-0 left-0 p-3 bg-gray-100"
        style={{
          width: "205px",
          height: "100vh",
        }}
      >
        <a href="/" className="text-gray-800 text-decoration-none">
          <span className="text-lg font-semibold ml-2">POS</span>
        </a>
        <ul className="list-none p-1 mt-5">
          {sections.map(({ component: Component, key }) => (
            <Component
              key={key}
              t={t}
              setOpen={() => toggleSection(key)}
              open={openSection === key}
            />
          ))}
        </ul>
      </div>

      <div
        className="ml-[205px] mt-[60px]"
        style={{
          width: "calc(100% - 205px)",
        }}
      ></div>
    </div>
  );
}
