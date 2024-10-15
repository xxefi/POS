import {
  Checkbox,
  FormControlLabel,
  FormControl,
  InputLabel,
  Select,
  SelectChangeEvent,
} from "@mui/material";
import { ChangeEvent, Fragment } from "react";

interface SettingsFormProps {
  tabIndex: number;
  settings: Record<string, any>;
  handleChange: (
    e: ChangeEvent<HTMLInputElement | HTMLSelectElement> | SelectChangeEvent
  ) => void;
  t: (key: string) => string;
}

export default function GeneralSettingsForm({
  tabIndex,
  settings,
  handleChange,
  t,
}: SettingsFormProps) {
  const handleSelectChange = (event: SelectChangeEvent) => {
    const { name, value } = event.target;
    handleChange({
      target: { name, value },
    } as ChangeEvent<HTMLSelectElement>);
  };

  return (
    <Fragment>
      {tabIndex === 0 && (
        <div>
          {Object.entries(settings).map(([key, value]) => (
            <div className="flex items-center mb-4" key={key}>
              <label className="w-1/3 block font-medium text-left">
                {t(key)}
              </label>
              <input
                type={key === "wifiPassword" ? "password" : "text"}
                name={key}
                value={value}
                onChange={handleChange}
                className="w-1/3 p-1 border rounded ml-2"
              />
            </div>
          ))}
        </div>
      )}

      {tabIndex === 1 && (
        <div>
          <FormControlLabel
            control={
              <Checkbox
                checked={settings.canCustomerBalanceBeNegative}
                onChange={handleChange}
                name="canCustomerBalanceBeNegative"
              />
            }
            label={t("canCustomerBalanceBeNegative")}
          />

          <FormControl
            variant="outlined"
            sx={{ display: "flex", mt: 2, minWidth: 200, marginBottom: "10px" }}
          >
            <InputLabel>{t("selectedTerminalAccount")}</InputLabel>
            <Select
              name="selectedTerminalAccount"
              value={settings.selectedTerminalAccount}
              onChange={handleSelectChange}
              label={t("selectedTerminalAccount")}
            ></Select>
          </FormControl>
        </div>
      )}

      {tabIndex === 2 && (
        <div>
          <label className="w-1/3 block font-medium text-left">
            {t("returnPolicy")}
          </label>
          <input
            type="text"
            name="returnPolicy"
            value={settings.returnPolicy}
            onChange={handleChange}
            className="w-1/3 p-1 border rounded ml-2"
          />
        </div>
      )}
    </Fragment>
  );
}
