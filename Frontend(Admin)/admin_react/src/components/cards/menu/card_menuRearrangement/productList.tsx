import {
  ProductData,
  CategoryMenuData,
} from "../../../interfaces/component.types";
import { useTranslation } from "react-i18next";

interface ProductListProps {
  selectedCategory: CategoryMenuData | null;
  products: ProductData[];
}

export function ProductList({ selectedCategory, products }: ProductListProps) {
  const { t } = useTranslation("common");

  const productsForSelectedCategory = selectedCategory
    ? products.filter((product) => product.category === selectedCategory.name)
    : [];

  return (
    <div className="products-list bg-white border border-gray-100 rounded-xl p-4">
      {selectedCategory ? (
        <>
          <h3 className="text-lg font-semibold mb-2 text-gray-500">
            {t("productsInCategory")}: {selectedCategory.name}
          </h3>
          <ul className="bg-white border border-gray-100 rounded-xl p-4">
            {productsForSelectedCategory.length > 0 ? (
              productsForSelectedCategory.map((product) => (
                <li
                  key={product.id}
                  className="product-item flex justify-between items-center p-3 mb-2 bg-gray-50 rounded-lg shadow-sm hover:bg-gray-100 transition duration-200 ease-in-out"
                >
                  <span>{product.name}</span>
                </li>
              ))
            ) : (
              <p className="text-red-500 font-medium">{t("noProductsFound")}</p>
            )}
          </ul>
        </>
      ) : (
        <p className="text-gray-600"></p>
      )}
    </div>
  );
}
