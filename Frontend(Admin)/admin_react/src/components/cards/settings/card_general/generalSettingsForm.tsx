import { Checkbox, Form, Input, SelectPicker } from "rsuite";
import { ChangeEvent, CSSProperties, Fragment } from "react";

interface SettingsFormProps {
  tabIndex: number;
  settings: Record<string, any>;
  handleChange: (e: ChangeEvent<HTMLInputElement | HTMLSelectElement>) => void;
  t: (key: string) => string;
}

const renderSelectField = (
  key: string,
  value: any,
  handleSelectChange: (value: string, name: string) => void,
  label: string,
  options: { label: string; value: string }[],
  t: (key: string) => string
) => (
  <div key={key} style={formRowStyle}>
    <Form.ControlLabel style={labelStyle}>{label}</Form.ControlLabel>
    <SelectPicker
      data={options}
      value={value}
      onChange={(value) => handleSelectChange(value, key)}
      style={inputStyle}
      placeholder={t("select")}
    />
  </div>
);

const formRowStyle: CSSProperties = {
  display: "flex",
  alignItems: "center",
  marginBottom: "16px",
  marginLeft: "7px",
};

const labelStyle: CSSProperties = {
  width: "30%",
  textAlign: "left",
};

const inputStyle: CSSProperties = {
  width: "20%",
};

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

  const getInputType = (key: string, value: any) => {
    if (typeof value === "boolean") return "checkbox";
    if (typeof value === "number") return "number";
    if (key === "wifiPassword") return "password";
    return "text";
  };

  const renderField = (key: string, value: any) => {
    const inputType = getInputType(key, value);

    if (
      key == "selectedTerminalAccountOptions" ||
      key == "returnsStorageOptions"
    )
      return;

    const options = settings[`${key}Options`] || [];

    if (key === "selectedTerminalAccount" || key === "returnsStorage")
      return renderSelectField(
        key,
        value,
        handleSelectChange,
        t(key),
        options,
        t
      );

    if (inputType === "checkbox") {
      return (
        <div key={key} style={formRowStyle}>
          <Form.ControlLabel style={labelStyle}>{t(key)}</Form.ControlLabel>
          <Checkbox
            name={key}
            checked={value}
            onChange={(_, checked) =>
              handleChange({
                target: { name: key, checked, type: "checkbox" },
              } as ChangeEvent<HTMLInputElement>)
            }
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
              target: { name: key, value, type: inputType },
            } as ChangeEvent<HTMLInputElement>)
          }
          style={inputStyle}
        />
      </div>
    );
  };

  const renderTabContent = () => (
    <div className="mt-5">
      {Object.entries(settings).map(([key, value]) => renderField(key, value))}
    </div>
  );

  return (
    <Fragment>{[0, 1, 2].includes(tabIndex) && renderTabContent()}</Fragment>
  );
}
