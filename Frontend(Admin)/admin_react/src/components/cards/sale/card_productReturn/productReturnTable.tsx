import { useTranslation } from "react-i18next";
import { ProductReturnData } from "../../../interfaces/component.types.ts";

interface ProductReturnTableProps {
  productReturn: ProductReturnData[];
}

export default function ProductReturnTable({
  productReturn,
}: ProductReturnTableProps) {
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
              <span>{t("operationTime")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("products")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("storage")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("receipt")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("waiter")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("terminal")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("customer")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("amount")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left rounded-tr-lg">
              <span>{t("paymentMethod")}</span>
            </td>
          </tr>
        </thead>
        <tbody>
          {productReturn.length === 0 ? (
            <tr>
              <td
                colSpan={10}
                className="py-3 px-4 text-center bg-white rounded-lg shadow-sm"
              >
                <span>{t("noDataFound")}</span>
              </td>
            </tr>
          ) : (
            productReturn.map((productReturn, index) => (
              <tr
                key={productReturn.id}
                className={`bg-white shadow-sm hover:bg-gray-100 ${
                  index % 2 === 0 ? "bg-gray-50" : "bg-white"
                }`}
              >
                <td className="py-3 px-4 rounded-l-lg">{productReturn.id}</td>
                <td className="py-3 px-4">{productReturn.operationTime}</td>
                <td className="py-3 px-4">{productReturn.products}</td>
                <td className="py-3 px-4">{productReturn.storage}</td>
                <td className="py-3 px-4">{productReturn.receipt}</td>
                <td className="py-3 px-4">{productReturn.waiter}</td>
                <td className="py-3 px-4">{productReturn.terminal}</td>
                <td className="py-3 px-4">{productReturn.customer}</td>
                <td className="py-3 px-4">{productReturn.amount}</td>
                <td className="py-3 px-4 rounded-r-lg">
                  {productReturn.paymentMethod}
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}
