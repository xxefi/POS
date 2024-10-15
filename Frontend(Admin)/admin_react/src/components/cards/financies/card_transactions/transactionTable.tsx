import { useTranslation } from "react-i18next";
import { TransactionData } from "../../../interfaces/component.types";

interface TransactionTableProps {
  transaction: TransactionData[];
}

export default function TransactionTable({
  transaction,
}: TransactionTableProps) {
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
              <span>{t("createdAt")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("transactedBy")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("category")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("reference")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("description")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("paymentMethod")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("amount")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("account")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("type")}</span>
            </td>
          </tr>
        </thead>
        <tbody>
          {transaction.length === 0 ? (
            <tr>
              <td
                colSpan={12}
                className="py-3 px-4 text-center bg-white rounded-lg shadow-sm"
              >
                <span>{t("noDataFound")}</span>
              </td>
            </tr>
          ) : (
            transaction.map((transaction, index) => (
              <tr
                key={transaction.id}
                className={`bg-white shadow-sm hover:bg-gray-100 ${
                  index % 2 === 0 ? "bg-gray-50" : "bg-white"
                }`}
              >
                <td className="py-3 px-4 rounded-l-lg">
                  <span>{transaction.id}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{transaction.operationTime}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{transaction.createdAt}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{transaction.transactedBy}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{transaction.category}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{transaction.reference}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{transaction.description}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{transaction.paymentMethod}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{transaction.amount}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{transaction.account}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{transaction.type}</span>
                </td>
                <td className="py-3 px-4 rounded-r-lg">
                  <span>{transaction.type}</span>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}
