import { useTranslation } from "react-i18next";
import { OrderNotificationsData } from "../../../interfaces/component.types.ts";
import CheckCircleIcon from "@mui/icons-material/CheckCircle";
import CancelIcon from "@mui/icons-material/Cancel";

interface OrderNotificationsTableProps {
  orderNotifications: OrderNotificationsData[];
}

export default function OrderNotificationsTable({
  orderNotifications,
}: OrderNotificationsTableProps) {
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
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("createdAt")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("integration")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("acceptedBy")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("terminal")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("receipt")} ID</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("integrationStatus")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left rounded-tr-lg">
              <span>{t("status")}</span>
            </td>
          </tr>
        </thead>
        <tbody>
          {orderNotifications.length === 0 ? (
            <tr>
              <td
                colSpan={8}
                className="py-3 px-4 text-center bg-white rounded-lg shadow-sm"
              >
                <span>{t("noDataFound")}</span>
              </td>
            </tr>
          ) : (
            orderNotifications.map((orderNotification, index) => (
              <tr
                key={orderNotification.id}
                className={`bg-white shadow-sm hover:bg-gray-100 ${
                  index % 2 === 0 ? "bg-gray-50" : "bg-white"
                }`}
              >
                <td className="py-3 px-4 rounded-l-lg">
                  {orderNotification.id}
                </td>
                <td className="py-3 px-4">
                  <span>{orderNotification.createdAt}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{orderNotification.integration}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{orderNotification.acceptedBy}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{orderNotification.terminal}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{orderNotification.receiptId}</span>
                </td>
                <td className="py-3 px-4">
                  {renderIcon(orderNotification.integrationStatus)}
                </td>
                <td className="py-3 px-4 rounded-r-lg">
                  {renderIcon(orderNotification.status)}
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}
