import { Form } from "rsuite";
import { BrandInputProps } from "../../../interfaces/component.props";
import { useTranslation } from "react-i18next";

export default function BrandInput({
  formData,
  handleChange,
}: BrandInputProps) {
  const { t } = useTranslation("common");

  return (
    <Form.Group>
      <Form.ControlLabel className="block text-lg mb-2 text-gray-800">
        {t("brandLabel")}
      </Form.ControlLabel>
      <Form.Control
        name="brand"
        value={formData.brand}
        onChange={(value) => handleChange({ brand: value })}
        placeholder={t("brandPlaceholder")}
        className="border rounded-lg p-3 shadow-md focus:outline-none focus:ring-2 focus:ring-blue-500"
      />
    </Form.Group>
  );
}
