import { AccountData } from "../../../interfaces/component.types.ts";
import { useTranslation } from "react-i18next";
interface AccountTableProps {
  account: AccountData[];
}

export default function AccountTable({ account }: AccountTableProps) {
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
              <span>{t("description")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("type")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left rounded-tr-lg">
              <span>{t("amount")}</span>
            </td>
          </tr>
        </thead>
        <tbody>
          {account.length === 0 ? (
            <tr>
              <td
                colSpan={8}
                className="py-3 px-4 text-center bg-white rounded-lg shadow-sm"
              >
                <span>{t("noDataFound")}</span>
              </td>
            </tr>
          ) : (
            account.map((account, index) => (
              <tr
                key={account.id}
                className={`bg-white shadow-sm hover:bg-gray-100 ${
                  index % 2 === 0 ? "bg-gray-50" : "bg-white"
                }`}
              >
                <td className="py-3 px-4 rounded-l-lg">
                  <span>{account.id}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{account.name}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{account.description}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{account.type}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{account.amount}</span>
                </td>
                <td className="py-3 px-4 rounded-r-lg">
                  <span>{account.amount}</span>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}
