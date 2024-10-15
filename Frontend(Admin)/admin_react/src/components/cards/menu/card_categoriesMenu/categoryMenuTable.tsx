import { useTranslation } from "react-i18next";
import { CategoryMenuData } from "../../../interfaces/component.types.ts";
import CheckCircleIcon from "@mui/icons-material/CheckCircle";
import CancelIcon from "@mui/icons-material/Cancel";

interface CategoryMenuTableProps {
  categoryMenu: CategoryMenuData[];
}

export default function CategoryMenuTable({
  categoryMenu,
}: CategoryMenuTableProps) {
  const { t } = useTranslation("common");

  const renderIcon = (condition: boolean) => {
    return (
      <span
        className={`inline-flex items-center justify-center w-5 h-5 rounded-full ${
          condition ? "bg-green-100" : "bg-red-100"
        }`}
      >
        {condition ? (
          <CheckCircleIcon
            className="text-green-500"
            style={{ fontSize: "16px" }}
          />
        ) : (
          <CancelIcon className="text-red-500" style={{ fontSize: "16px" }} />
        )}
      </span>
    );
  };

  return (
    <div className="mt-5 overflow-x-auto rounded-xl shadow-lg">
      <table
        className="min-w-full bg-white border-separate"
        style={{ borderSpacing: "5" }}
      >
        <thead>
          <tr className="text-gray-700">
            <td className="py-3 px-4 bg-gray-100 text-left rounded-tl-lg">
              ID
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left ">
              <span>{t("name")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("status")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("count")}</span>
            </td>
          </tr>
        </thead>
        <tbody>
          {categoryMenu.length === 0 ? (
            <tr>
              <td
                colSpan={4}
                className="py-3 px-4 text-center bg-white rounded-lg shadow-sm"
              >
                <span>{t("noDataFound")}</span>
              </td>
            </tr>
          ) : (
            categoryMenu.map((categoryMenu, index) => (
              <tr
                key={categoryMenu.id}
                className={`bg-white shadow-sm hover:bg-gray-100 ${
                  index % 2 === 0 ? "bg-gray-50" : "bg-white"
                }`}
              >
                <td className="py-3 px-4 rounded-l-lg">
                  <span>{categoryMenu.id}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{categoryMenu.name}</span>
                </td>
                <td className="py-3 px-4">{renderIcon(categoryMenu.status)}</td>
                <td className="py-3 px-4 rounded-r-lg">
                  <span>{categoryMenu.count}</span>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}
