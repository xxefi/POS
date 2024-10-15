import { Box, Button, Fade, Modal } from "@mui/material";
import { useTranslation } from "react-i18next";
import HistoryFilters from "./historyFilters.tsx";

interface HistoryFiltersModalProps {
  isModalOpen: boolean;
  setIsModalOpen: (isOpen: boolean) => void;
}

export default function HistoryFiltersModal({
  isModalOpen,
  setIsModalOpen,
}: HistoryFiltersModalProps) {
  const { t } = useTranslation("common");

  const modalStyle = {
    position: "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
    width: "90%",
    maxWidth: "600px",
    bgcolor: "background.paper",
    boxShadow: 24,
    p: 4,
    borderRadius: "10px",
  };
  return (
    <Modal
      open={isModalOpen}
      onClose={() => setIsModalOpen(false)}
      closeAfterTransition
      disableScrollLock
    >
      <Fade in={isModalOpen}>
        <Box sx={modalStyle}>
          <div className="flex items-center justify-between border-b mb-4 pb-2">
            <h3 className="text-lg font-semibold text-gray-900">
              {t("filters")}
            </h3>
            <Button
              variant="text"
              color="inherit"
              onClick={() => setIsModalOpen(false)}
            >
              <svg
                className="w-5 h-5"
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M6 18L18 6M6 6l12 12"
                />
              </svg>
            </Button>
          </div>
          <HistoryFilters />
        </Box>
      </Fade>
    </Modal>
  );
}
