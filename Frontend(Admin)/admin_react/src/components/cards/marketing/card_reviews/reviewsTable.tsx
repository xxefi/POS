import { useTranslation } from "react-i18next";
import { ReviewsData } from "../../../interfaces/component.types";

interface ReviewsTableProps {
  reviews: ReviewsData[];
}

export default function ReviewsTable({ reviews }: ReviewsTableProps) {
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
              <span>{t("type")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("fullName")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("service")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("food")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("delivery")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left rounded-tr-lg">
              <span>{t("actions")}</span>
            </td>
          </tr>
        </thead>
        <tbody>
          {reviews.length === 0 ? (
            <tr>
              <td
                colSpan={7}
                className="py-3 px-4 text-center bg-white rounded-lg shadow-sm"
              >
                <span>{t("noDataFound")}</span>
              </td>
            </tr>
          ) : (
            reviews.map((review, index) => (
              <tr
                key={review.id}
                className={`bg-white shadow-sm hover:bg-gray-100 ${
                  index % 2 === 0 ? "bg-gray-50" : "bg-white"
                }`}
              >
                <td className="py-3 px-4 rounded-l-lg">
                  <span>{review.id}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{review.type}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{review.fullName}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{review.service}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{review.food}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{review.delivery}</span>
                </td>
                <td className="py-3 px-4 rounded-r-lg">
                  <button className="text-blue-500 hover:underline">
                    {t("view")}
                  </button>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}
