import { useTranslation } from "react-i18next";
import { Button, Box, Menu, MenuItem } from "@mui/material";
import { useEffect, useState } from "react";
import { MouseEvent } from "react";

import LanguageIcon from "@mui/icons-material/Language";
import UnitedKingdom from "./components/flags/UK";
import Russia from "./components/flags/RU";
import Azerbaijan from "./components/flags/AZ";
import Japan from "./components/flags/JP";
import Turkey from "./components/flags/TR";
import Germany from "./components/flags/DE.tsx";

export default function LanguageSwitcher() {
  const { i18n } = useTranslation();
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);

  useEffect(() => {
    const savedLanguage = localStorage.getItem("lang");
    if (savedLanguage) {
      i18n.changeLanguage(savedLanguage);
      document.documentElement.lang = savedLanguage;
    } else {
      localStorage.setItem("lang", "en");
      i18n.changeLanguage("en");
      document.documentElement.lang = "en";
    }
  }, [i18n]);

  const handleClick = (e: MouseEvent<HTMLButtonElement>) => {
    setAnchorEl(e.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const changeLanguage = (lang: string) => {
    i18n.changeLanguage(lang);
    localStorage.setItem("lang", lang);
    document.documentElement.lang = lang;
    handleClose();
  };

  return (
    <Box>
      <Button
        variant="contained"
        onClick={handleClick}
        sx={{
          backgroundColor: "#fff0",
          borderRadius: "50%",
          minWidth: "40px",
          minHeight: "20px",
          display: "flex",
          padding: "7px 4px",
          justifyContent: "center",
          alignItems: "center",
          "&:hover": {
            backgroundColor: "#e0e0e0",
          },
        }}
      >
        <LanguageIcon sx={{ color: "#000", opacity: 0.8 }} />
      </Button>

      <Menu
        anchorEl={anchorEl}
        open={Boolean(anchorEl)}
        onClose={handleClose}
        disableScrollLock
      >
        <MenuItem onClick={() => changeLanguage("en")}>
          <span className="flex items-center justify-center">
            <UnitedKingdom />
            <span className="ml-5">English</span>
          </span>
        </MenuItem>
        <MenuItem onClick={() => changeLanguage("ru")}>
          <span className="flex items-center justify-center">
            <Russia />
            <span className="ml-5">Русский</span>
          </span>
        </MenuItem>
        <MenuItem onClick={() => changeLanguage("az")}>
          <span className="flex justify-center items-center">
            <Azerbaijan />
            <span className="ml-5">Azərbaycan</span>
          </span>
        </MenuItem>
        <MenuItem onClick={() => changeLanguage("tr")}>
          <span className="flex justify-center items-center">
            <Turkey />
            <span className="ml-5">Türkçe</span>
          </span>
        </MenuItem>
        <MenuItem onClick={() => changeLanguage("ge")}>
          <span className="flex justify-center items-center">
            <Germany />
            <span className="ml-5">Deutsch</span>
          </span>
        </MenuItem>
        <MenuItem onClick={() => changeLanguage("jp")}>
          <span className="flex justify-center items-center">
            <Japan />
            <span className="ml-5">日本語</span>
          </span>
        </MenuItem>
      </Menu>
    </Box>
  );
}
