import { Form } from "rsuite";
import { PasswordInputProps } from "../../../interfaces/component.props";
import { useTranslation } from "react-i18next";

export default function PasswordInput({
  formData,
  handleChange,
}: PasswordInputProps) {
  const { t } = useTranslation("common");

  return (
    <Form.Group>
      <Form.ControlLabel className="block text-lg mb-2 text-gray-800">
        {t("passwordLabel")}
      </Form.ControlLabel>
      <Form.Control
        name="password"
        type="password"
        value={formData.password}
        onChange={(value) => handleChange({ password: value })}
        placeholder={t("passwordPlaceholder")}
        className="border rounded-lg p-3 shadow-md focus:outline-none focus:ring-2 focus:ring-blue-500"
      />
    </Form.Group>
  );
}
