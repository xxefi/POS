import { useTranslation } from "react-i18next";
import { ReportData } from "../../../interfaces/component.types.ts";
import { ChangeEvent, useState } from "react";
import { TablePagination } from "@mui/material";

interface ReportsTableProps {
  reports: ReportData[];
}

export default function ReportsTable({ reports }: ReportsTableProps) {
  const { t } = useTranslation("common");
  const [page, setPage] = useState<number>(0);
  const [rowsPerPage, setRowsPerPage] = useState<number>(5);

  const handleChangePage = (newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (e: ChangeEvent<HTMLInputElement>) => {
    setRowsPerPage(parseInt(e.target.value));
    setPage(0);
  };

  return (
    <div className="mt-5 overflow-x-auto rounded-xl shadow-lg">
      <table
        className="min-w-full bg-white border-separate"
        style={{ borderSpacing: "1" }}
      >
        <thead>
          <tr className="text-gray-700">
            {[
              "ID",
              "name",
              "type",
              "category",
              "count",
              "price",
              "revenue",
              "profit",
            ].map((header, index) => (
              <td key={index} className="py-3 px-4 bg-gray-100 text-left">
                <span>{t(header)}</span>
              </td>
            ))}
          </tr>
        </thead>
        <tbody>
          {reports.length === 0 ? (
            <tr>
              <td
                colSpan={8}
                className="py-3 px-4 text-center bg-white rounded-lg shadow-sm"
              >
                <span>{t("noDataFound")}</span>
              </td>
            </tr>
          ) : (
            reports
              .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
              .map((report, index) => (
                <tr
                  key={report.id}
                  className={`bg-white shadow-sm hover:bg-gray-100 ${
                    index % 2 === 0 ? "bg-gray-50" : "bg-white"
                  }`}
                >
                  <td className="py-3 px-4 rounded-l-lg">
                    <span>{report.id}</span>
                  </td>
                  <td className="py-3 px-4">
                    <span>{report.name}</span>
                  </td>
                  <td className="py-3 px-4">
                    <span>{report.type}</span>
                  </td>
                  <td className="py-3 px-4">
                    <span>{report.category}</span>
                  </td>
                  <td className="py-3 px-4">
                    <span>{report.count}</span>
                  </td>
                  <td className="py-3 px-4">
                    <span>{report.price}</span>
                  </td>
                  <td className="py-3 px-4">
                    <span>{report.revenue}</span>
                  </td>
                  <td className="py-3 px-4 rounded-r-lg">
                    <span>{report.profit}</span>
                  </td>
                </tr>
              ))
          )}
        </tbody>
      </table>
      <TablePagination
        rowsPerPageOptions={[5, 10, 25, 50, 100]}
        component="div"
        count={reports.length}
        rowsPerPage={rowsPerPage}
        page={page}
        onPageChange={(_, newPage) => handleChangePage(newPage)}
        onRowsPerPageChange={handleChangeRowsPerPage}
        labelRowsPerPage={t("rowsPerPage")}
      />
    </div>
  );
}
