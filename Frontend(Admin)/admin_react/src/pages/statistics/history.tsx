import { Button } from "@mui/material";
import { useEffect, useState } from "react";
import MenuIcon from "@mui/icons-material/Menu";
import { useTranslation } from "react-i18next";
import { HistoryData } from "../../components/interfaces/component.types";
import HistoryTable from "../../components/cards/statistics/card_history/historyTable";
import HistoryFiltersModal from "../../components/cards/statistics/card_history/historyFiltersModal";

export default function History() {
  const { t } = useTranslation("common");
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);

  const histories: HistoryData[] = [];

  useEffect(() => {
    document.title = t("history");
  }, []);

  return (
    <div className="flex flex-col justify-center">
      <span className="text-gray-500 font-medium text-xl">{t("history")}</span>

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
          <MenuIcon sx={{ fontSize: "20px" }} />
          <span className="ml-2 text-sm">{t("filters")}</span>
        </span>
      </Button>

      <HistoryTable histories={histories} />

      <HistoryFiltersModal
        isModalOpen={isModalOpen}
        setIsModalOpen={setIsModalOpen}
      />
    </div>
  );
}
