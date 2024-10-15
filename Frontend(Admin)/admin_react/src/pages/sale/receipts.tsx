import { useEffect, useState } from "react";
import { useTranslation } from "react-i18next";
import { Button } from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import { ReceiptData } from "../../components/interfaces/component.types";
import ReceiptsTable from "../../components/cards/sale/card_receipts/receiptsTable";
import ReceiptsModal from "../../components/cards/sale/card_receipts/receiptsModal";

const receipts: ReceiptData[] = [];
export default function Receipts() {
  const { t } = useTranslation("common");
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);

  useEffect(() => {
    document.title = t("receipts");
  }, []);

  return (
    <div className="flex flex-col justify-center">
      <span className="text-gray-500 font-medium text-xl">{t("receipts")}</span>

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

      <ReceiptsTable receipts={receipts} />

      <ReceiptsModal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
      />
    </div>
  );
}
