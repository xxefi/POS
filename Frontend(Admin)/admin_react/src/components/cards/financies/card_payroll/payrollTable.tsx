import { useTranslation } from "react-i18next";
import { PayrollData } from "../../../interfaces/component.types";

interface PayrollTableProps {
  payroll: PayrollData[];
}

export default function PayrollTable({ payroll }: PayrollTableProps) {
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
              <span>{t("username")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("role")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("totalPayment")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("salary")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("paidAmount")}</span>
            </td>
          </tr>
        </thead>
        <tbody>
          {payroll.length === 0 ? (
            <tr>
              <td
                colSpan={8}
                className="py-3 px-4 text-center bg-white rounded-lg shadow-sm"
              >
                <span>{t("noDataFound")}</span>
              </td>
            </tr>
          ) : (
            payroll.map((payroll, index) => (
              <tr
                key={payroll.id}
                className={`bg-white shadow-sm hover:bg-gray-100 ${
                  index % 2 === 0 ? "bg-gray-50" : "bg-white"
                }`}
              >
                <td className="py-3 px-4 rounded-l-lg">
                  <span>{payroll.id}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{payroll.username}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{payroll.role}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{payroll.totalPayment}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{payroll.salary}</span>
                </td>
                <td className="py-3 px-4 rounded-r-lg">
                  <span>{payroll.paidAmount}</span>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}
