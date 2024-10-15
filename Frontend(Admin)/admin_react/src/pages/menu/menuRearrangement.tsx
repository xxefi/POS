import { useEffect, useState } from "react";
import { useTranslation } from "react-i18next";
import MenuRearrangementCard from "../../components/cards/menu/card_menuRearrangement/menuRearrangementCard";
import {
  CategoryMenuData,
  ProductData,
} from "../../components/interfaces/component.types";

export default function MenuRearrangement() {
  const { t } = useTranslation("common");
  useEffect(() => {
    document.title = t("menuRearrangement");
  }, []);

  const [categories, setCategories] = useState<CategoryMenuData[]>([]);

  const [products, setProducts] = useState<ProductData[]>([]);

  return (
    <div>
      <span className="text-gray-500 font-medium text-xl">
        {t("menuRearrangement")}
      </span>
      <MenuRearrangementCard categories={categories} products={products} />
    </div>
  );
}
