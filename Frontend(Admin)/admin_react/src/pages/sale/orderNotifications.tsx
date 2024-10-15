import { useTranslation } from "react-i18next";
import { useEffect, useState } from "react";
import MenuIcon from "@mui/icons-material/Menu";
import { Button } from "@mui/material";
import { OrderNotificationsData } from "../../components/interfaces/component.types";
import OrderNotificationsTable from "../../components/cards/sale/card_orderNotifications/orderNotificationsTable";
import OrderNotificationsModal from "../../components/cards/sale/card_orderNotifications/orderNotificationsModal";

const orderNotifications: OrderNotificationsData[] = [];
export default function OrderNotifications() {
  const { t } = useTranslation("common");
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);

  useEffect(() => {
    document.title = t("ordernotifications");
  }, []);

  return (
    <div className="flex flex-col justify-center">
      <span className="text-gray-500 font-medium text-xl">
        {t("ordernotifications")}
      </span>

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

      <OrderNotificationsTable orderNotifications={orderNotifications} />

      <OrderNotificationsModal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
      />
    </div>
  );
}
