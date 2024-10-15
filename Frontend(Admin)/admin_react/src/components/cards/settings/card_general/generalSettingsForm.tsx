import { Checkbox, Form, Input, SelectPicker, InputNumber } from "rsuite";
import { ChangeEvent, CSSProperties, Fragment } from "react";

interface SettingsFormProps {
  tabIndex: number;
  settings: Record<string, any>;
  handleChange: (e: ChangeEvent<HTMLInputElement | HTMLSelectElement>) => void;
  t: (key: string) => string;
}

export default function GeneralSettingsForm({
  tabIndex,
  settings,
  handleChange,
  t,
}: SettingsFormProps) {
  const handleSelectChange = (value: string, name: string) => {
    handleChange({
      target: { name, value },
    } as ChangeEvent<HTMLSelectElement>);
  };

  const renderField = (key: string, value: any) => {
    const isCheckbox = typeof value === "boolean";
    const inputType =
      key === "wifiPassword"
        ? "password"
        : typeof value === "number"
        ? "number"
        : "text";

    const formRowStyle: CSSProperties = {
      display: "flex",
      alignItems: "center",
      marginBottom: "16px",
    };

    const labelStyle: CSSProperties = {
      width: "20%",
      textAlign: "left",
      paddingRight: "16px",
    };

    const inputStyle: CSSProperties = {
      width: "30%",
    };

    if (isCheckbox) {
      return (
        <div key={key} style={formRowStyle}>
          <Checkbox
            checked={value}
            onChange={(checked) =>
              handleChange({
                target: { name: key, value: checked },
              } as ChangeEvent<HTMLInputElement>)
            }
          >
            {t(key)}
          </Checkbox>
        </div>
      );
    }

    if (typeof value === "number") {
      return (
        <div key={key} style={formRowStyle}>
          <Form.ControlLabel style={labelStyle}>{t(key)}</Form.ControlLabel>
          <InputNumber
            value={value}
            onChange={(newValue) =>
              handleChange({
                target: { name: key, value: newValue },
              } as ChangeEvent<HTMLInputElement>)
            }
            style={inputStyle}
          />
        </div>
      );
    }

    return (
      <div key={key} style={formRowStyle}>
        <Form.ControlLabel style={labelStyle}>{t(key)}</Form.ControlLabel>
        <Input
          type={inputType}
          name={key}
          value={value}
          onChange={(value) =>
            handleChange({
              target: { name: key, value },
            } as ChangeEvent<HTMLInputElement>)
          }
          style={inputStyle}
        />
      </div>
    );
  };

  return (
    <Fragment>
      {tabIndex === 0 && (
        <div>
          {Object.entries(settings).map(([key, value]) =>
            renderField(key, value)
          )}
        </div>
      )}

      {tabIndex === 1 && (
        <div>
          {renderField(
            "canCustomerBalanceBeNegative",
            settings.canCustomerBalanceBeNegative
          )}
          <div style={{ marginTop: "16px" }}>
            <Form.Group
              controlId="selectedTerminalAccount"
              style={{
                display: "flex",
                justifyContent: "space-between",
                alignItems: "center",
              }}
            >
              <Form.ControlLabel style={{ width: "30%" }}>
                {t("selectedTerminalAccount")}
              </Form.ControlLabel>
              <SelectPicker
                data={[]}
                value={settings.selectedTerminalAccount}
                onChange={(value) =>
                  handleSelectChange(value, "selectedTerminalAccount")
                }
                style={{ width: "70%" }}
              />
            </Form.Group>
          </div>
        </div>
      )}

      {tabIndex === 2 && (
        <div>
          {[
            "returnPolicy",
            "productReturn",
            "returnOfDiscountedReceipt",
            "maximumDayOfProductReturn",
            "returnsStorage",
          ].map((key) => renderField(key, settings[key]))}
        </div>
      )}
    </Fragment>
  );
}
