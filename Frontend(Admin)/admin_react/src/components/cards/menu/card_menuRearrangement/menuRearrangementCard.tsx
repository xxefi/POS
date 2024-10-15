import { useState } from "react";
import { useTranslation } from "react-i18next";
import {
  ProductData,
  CategoryMenuData,
} from "../../../interfaces/component.types";
import { Button } from "@mui/material";
import { Refresh } from "@mui/icons-material";
import CheckIcon from "@mui/icons-material/Check";
import { DropResult } from "react-beautiful-dnd";
import { CategoryList } from "./categoryList";
import { ProductList } from "./productList";

interface MenuRearrangementProps {
  categories: CategoryMenuData[];
  products: ProductData[];
}

export default function MenuRearrangementCard({
  categories: initialCategories,
  products: allProducts,
}: MenuRearrangementProps) {
  const { t } = useTranslation("common");
  const [categories, setCategories] = useState(initialCategories);
  const [selectedCategory, setSelectedCategory] =
    useState<CategoryMenuData | null>(null);

  const handleDragEnd = (result: DropResult) => {
    if (!result.destination) return;

    const newCategories = Array.from(categories);
    const [movedCategory] = newCategories.splice(result.source.index, 1);
    newCategories.splice(result.destination.index, 0, movedCategory);

    setCategories(newCategories);
  };

  const resetCategories = () => {
    setCategories(initialCategories);
    setSelectedCategory(null);
  };

  const saveChanges = () => {
    console.log(categories);
  };

  return (
    <div className="menu-rearrangement-container grid grid-cols-2 gap-4 p-5">
      <CategoryList
        categories={categories}
        selectedCategory={selectedCategory}
        setSelectedCategory={setSelectedCategory}
        handleDragEnd={handleDragEnd}
      />

      <ProductList selectedCategory={selectedCategory} products={allProducts} />

      <div className="flex justify-between mt-4">
        <Button
          variant="contained"
          color="error"
          startIcon={<Refresh />}
          onClick={resetCategories}
          sx={{ textTransform: "none", borderRadius: "10px" }}
        >
          <span>{t("reset")}</span>
        </Button>
        <Button
          variant="contained"
          color="success"
          startIcon={<CheckIcon />}
          onClick={saveChanges}
          sx={{
            backgroundColor: "#4caf50",
            color: "white",
            textTransform: "none",
            boxShadow: "none",
            borderRadius: "10px",
            "&:hover": {
              backgroundColor: "#388e3c",
            },
          }}
        >
          <span>{t("save")}</span>
        </Button>
      </div>
    </div>
  );
}
