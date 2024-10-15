import { useEffect, useState } from "react";
import { useTranslation } from "react-i18next";
import { CategoryMenuData } from "../../components/interfaces/component.types.ts";
import { Button } from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import CategoryMenuTable from "../../components/cards/menu/card_categoriesMenu/categoryMenuTable.tsx";
import CategoryMenuModal from "../../components/cards/menu/card_categoriesMenu/categoryMenuModal.tsx";
import { Link } from "react-router-dom";
import AddIcon from "@mui/icons-material/Add";

const categoriesMenu: CategoryMenuData[] = [];

export default function CategoriesMenu() {
  const { t } = useTranslation("common");
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
  useEffect(() => {
    document.title = t("categories");
  }, []);
  return (
    <div className="flex flex-col justify-center">
      <span className="text-gray-500 font-medium text-xl">
        {t("categories")}
      </span>

      <div className="flex justify-between items-center mt-4">
        <Button
          onClick={() => setIsModalOpen(true)}
          variant="contained"
          sx={{
            backgroundColor: "rgb(242, 244, 248)",
            color: "black",
            textTransform: "none",
            width: "120px",
            borderRadius: "10px",
            boxShadow: "none",
          }}
        >
          <span className="flex items-center justify-center">
            <MenuIcon sx={{ fontSize: "20px" }} />
            <span className="ml-2 text-sm">{t("filters")}</span>
          </span>
        </Button>
        <Button
          component={Link}
          to="/menu/categories/create"
          variant="contained"
          sx={{
            color: "white",
            textTransform: "none",
            width: "110px",
            borderRadius: "10px",
            boxShadow: "none",
          }}
        >
          <span className="flex items-center justify-center">
            <AddIcon sx={{ fontSize: "20px" }} />
            <span className="ml-2 text-sm">{t("create")}</span>
          </span>
        </Button>
      </div>

      <CategoryMenuTable categoryMenu={categoriesMenu} />

      <CategoryMenuModal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
      />
    </div>
  );
}
