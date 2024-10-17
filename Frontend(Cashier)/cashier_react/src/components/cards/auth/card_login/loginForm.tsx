import { Button, Form, Panel } from "rsuite";
import { useTranslation } from "react-i18next";
import { LoginFormProps } from "../../../interfaces/component.props";
import BrandInput from "./brandInput";
import PasswordInput from "./passwordInput";
import PinCodeInput from "./pinCodeInput";

export default function LoginForm({
  step,
  formData,
  handleChange,
  handlePinCodeInput,
  handlePinCodeDelete,
  handleSubmit,
}: LoginFormProps) {
  const { t } = useTranslation("common");

  return (
    <Panel
      header={
        <h3 className="flex text-4xl font-bold mb-6 text-center items-center justify-center">
          {t("loginHeader")}
        </h3>
      }
      bordered
      className="shadow-lg p-10 rounded-lg bg-white w-full max-w-md"
    >
      <Form fluid>
        {step === 1 && (
          <BrandInput formData={formData} handleChange={handleChange} />
        )}
        {step === 2 && (
          <PasswordInput formData={formData} handleChange={handleChange} />
        )}
        {step === 3 && (
          <PinCodeInput
            formData={formData}
            handlePinCodeInput={handlePinCodeInput}
            handlePinCodeDelete={handlePinCodeDelete}
          />
        )}
        <Form.Group>
          <Button
            appearance="primary"
            type="submit"
            className="w-full rounded-lg text-xl py-3 text-center bg-blue-600 hover:bg-blue-700 transition duration-200"
            onClick={() => handleSubmit(true)}
          >
            {step < 3 ? t("next") : t("login")}
          </Button>
        </Form.Group>
      </Form>
    </Panel>
  );
}
