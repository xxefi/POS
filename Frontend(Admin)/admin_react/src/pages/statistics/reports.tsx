import { useEffect, useState } from "react";
import { useTranslation } from "react-i18next";
import Button from "@mui/material/Button";
import MenuIcon from "@mui/icons-material/Menu";
import "react-datepicker/dist/react-datepicker.css";
import {
  ButtonData,
  ReportData,
} from "../../components/interfaces/component.types";
import ReportButtons from "../../components/cards/statistics/card_reports/reportsButton";
import ReportsTable from "../../components/cards/statistics/card_reports/reportsTable";
import ReportFiltersModal from "../../components/cards/statistics/card_reports/reportFiltersModal";

export default function Reports() {
  const { t } = useTranslation("common");
  const [active, setActive] = useState<number>(0);
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);

  const reports: ReportData[] = [];

  const buttonData: ButtonData[] = [
    { label: t("products"), isActive: active === 0 },
    { label: t("modifiers"), isActive: active === 1 },
    { label: t("return"), isActive: active === 2 },
    { label: t("tables"), isActive: active === 3 },
    { label: t("salesmethods"), isActive: active === 4 },
    { label: t("categories"), isActive: active === 5 },
    { label: t("staff"), isActive: active === 6 },
    { label: t("stations"), isActive: active === 7 },
    { label: t("customers"), isActive: active === 8 },
    { label: t("payments"), isActive: active === 9 },
  ];

  useEffect(() => {
    document.title = t("reports");
  }, []);

  return (
    <div className="flex flex-col justify-center ">
      <span className="text-gray-500 font-medium text-xl mb-4">
        {t("reports")} / {t(buttonData[active].label)}
      </span>
      <ReportButtons
        buttonData={buttonData}
        active={active}
        setActive={setActive}
      />
      <Button
        onClick={() => setIsModalOpen(true)}
        variant="contained"
        sx={{
          backgroundColor: "rgb(242, 244, 248)",
          color: "black",
          marginTop: "1rem",
          textTransform: "none",
          width: "120px",
          borderRadius: "10px",
          boxShadow: "none",
        }}
      >
        <span className="flex items-center justify-center">
          <span>
            <MenuIcon sx={{ fontSize: "20px" }} />
          </span>
          <span className="ml-2 text-sm">{t("filters")}</span>
        </span>
      </Button>

      <ReportsTable reports={reports} />

      <ReportFiltersModal
        isModalOpen={isModalOpen}
        setIsModalOpen={setIsModalOpen}
      />
    </div>
  );
}
