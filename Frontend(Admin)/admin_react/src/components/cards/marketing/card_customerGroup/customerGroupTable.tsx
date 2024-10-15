import { useTranslation } from "react-i18next";
import { CustomerGroupData } from "../../../interfaces/component.types";

interface CustomerGroupTableProps {
  customerGroup: CustomerGroupData[];
}

export default function CustomerGroupTable({
  customerGroup,
}: CustomerGroupTableProps) {
  const { t } = useTranslation("common");
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
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("name")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("discountValue")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left rounded-tr-lg">
              <span>{t("balance")}</span>
            </td>
          </tr>
        </thead>
        <tbody>
          {customerGroup.length === 0 ? (
            <tr>
              <td
                colSpan={4}
                className="py-3 px-4 text-center bg-white rounded-lg shadow-sm"
              >
                <span>{t("noDataFound")}</span>
              </td>
            </tr>
          ) : (
            customerGroup.map((group, index) => (
              <tr
                key={group.id}
                className={`bg-white shadow-sm hover:bg-gray-100 ${
                  index % 2 === 0 ? "bg-gray-50" : "bg-white"
                }`}
              >
                <td className="py-3 px-4 rounded-l-lg">
                  <span>{group.id}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{group.name}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{group.discount}%</span>
                </td>
                <td className="py-3 px-4 rounded-r-lg">
                  <span>{group.balance}</span>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}
