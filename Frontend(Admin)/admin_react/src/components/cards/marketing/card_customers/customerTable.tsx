import { CustomerData } from "../../../interfaces/component.types.ts";
import { useTranslation } from "react-i18next";

interface CustomerTableProps {
  customers: CustomerData[];
}

export default function CustomerTable({ customers }: CustomerTableProps) {
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
              <span>{t("group")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("phone")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("address")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("balance")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("dob")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left rounded-tr-lg">
              <span>{t("gender")}</span>
            </td>
          </tr>
        </thead>
        <tbody>
          {customers.length === 0 ? (
            <tr>
              <td
                colSpan={8}
                className="py-3 px-4 text-center bg-white rounded-lg shadow-sm"
              >
                <span>{t("noDataFound")}</span>
              </td>
            </tr>
          ) : (
            customers.map((customer, index) => (
              <tr
                key={customer.id}
                className={`bg-white shadow-sm hover:bg-gray-100 ${
                  index % 2 === 0 ? "bg-gray-50" : "bg-white"
                }`}
              >
                <td className="py-3 px-4 rounded-l-lg">
                  <span>{customer.id}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{customer.name}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{customer.group}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{customer.phone}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{customer.address}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{customer.balance}</span>
                </td>
                <td className="py-3 px-4">
                  <span>
                    {new Date(customer.dateOfBirth).toLocaleDateString()}
                  </span>
                </td>
                <td className="py-3 px-4 rounded-r-lg">
                  <span>{customer.gender}</span>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}
