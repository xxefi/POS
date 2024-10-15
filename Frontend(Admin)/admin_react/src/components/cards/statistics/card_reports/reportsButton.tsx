import Button from "@mui/material/Button";
import { ButtonData } from "../../../interfaces/component.types.ts";

interface ReportButtonsProps {
  buttonData: ButtonData[];
  active: number;
  setActive: (index: number) => void;
}

export default function ReportButtons({
  buttonData,
  setActive,
}: ReportButtonsProps) {
  return (
    <div
      id="shortcut"
      className="flex flex-wrap gap-2 rounded mt-3"
      style={{ fontSize: "13px" }}
    >
      {buttonData.map((button, index) => (
        <Button
          key={index}
          variant={button.isActive ? "contained" : "outlined"}
          sx={{
            textTransform: "none",
            backgroundColor: button.isActive ? "#000" : "rgb(242, 244, 248)",
            color: button.isActive ? "white" : "black",
            border: "0px",
            borderRadius: "10px",
            "&:hover": {
              boxShadow: "0px 4px 12px rgba(0, 0, 0, 0.3)",
            },
          }}
          onClick={() => setActive(index)}
        >
          {button.label}
        </Button>
      ))}
    </div>
  );
}
