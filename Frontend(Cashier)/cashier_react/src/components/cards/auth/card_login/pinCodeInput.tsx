import { Form } from "rsuite";
import { PinCodeProps } from "../../../interfaces/component.props";
import { useTranslation } from "react-i18next";
import { FaBackspace } from "react-icons/fa";

export default function PinCodeInput({
  formData,
  handlePinCodeInput,
  handlePinCodeDelete,
}: PinCodeProps) {
  const { t } = useTranslation("common");
  const pinCode = formData.pinCode || "";

  return (
    <div>
      <Form.Group>
        <Form.ControlLabel className="block text-lg mb-2 text-gray-800">
          {t("pinCodeLabel")}
        </Form.ControlLabel>
        <div className="flex justify-center mb-4">
          <div className="flex items-center justify-center border border-gray-300 rounded-lg w-full h-16 bg-gray-100 text-4xl">
            {pinCode.split("").map((digit, index) => (
              <span key={index} className="mx-3 font-bold">
                {digit}
              </span>
            ))}
          </div>
        </div>
      </Form.Group>

      <div className="grid grid-cols-3 gap-4 mb-4">
        {Array.from({ length: 9 }, (_, i) => (
          <button
            key={i + 1}
            onClick={() => handlePinCodeInput((i + 1).toString())}
            className="text-xl bg-blue-500 text-white rounded-lg p-8 hover:bg-blue-600 transition duration-200"
          >
            {i + 1}
          </button>
        ))}
      </div>

      <div className="grid grid-cols-2 gap-4 mb-4">
        <button
          onClick={() => handlePinCodeInput("0")}
          className="text-xl bg-blue-500 text-white rounded-lg p-4 hover:bg-blue-600 transition duration-200 col-span-1"
        >
          0
        </button>

        <button
          onClick={handlePinCodeDelete}
          className="text-xl bg-red-500 text-white rounded-lg p-4 hover:bg-red-600 transition duration-200 col-span-1 flex items-center justify-center"
        >
          <FaBackspace className="mr-2" />
          {t("remove")}
        </button>
      </div>
    </div>
  );
}
