import { useState, useEffect } from "react";

const useValidation = (value, validations, validated) => {
  const [emptyError, setEmptyError] = useState(false);
  const [minLengthError, setMinLengthError] = useState(false);
  const [maxLengthError, setMaxLengthError] = useState(false);
  const [priceError, setPriceError] = useState(false);

  const [inputValid, setInputValid] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");

  useEffect(() => {
    for (const validation in validations) {
      switch (validation) {
        case "isEmpty":
          if (value.length == 0) {
            setEmptyError(true);
            setErrorMessage("Строка не должна быть пустой!");
          } else {
            setEmptyError(false);
          }
          break;
        case "minLength":
          if (value.length < validations[validation]) {
            setMinLengthError(true);
            setErrorMessage(
              "Длина строки должна быть больше " +
                validations[validation] +
                " символов!"
            );
          } else {
            setMinLengthError(false);
          }
          break;
        case "maxLength":
          if (value.length > validations[validation]) {
            setMaxLengthError(true);
            setErrorMessage(
              "Длина строки должна быть меньше " +
                validations[validation] +
                " символов!"
            );
          } else {
            setMaxLengthError(false);
          }
          break;
        case "isPrice":
          const re = /(?<=^| )\d+(\.\d+)?(?=$| )/;
          if (re.test(String(value).trim())) {
            setPriceError(false);
          } else {
            setPriceError(true);
            setErrorMessage("Неверный формат цены!");
          }
          break;
      }
    }
  }, [value]);

  useEffect(() => {
    //console.log("emptyError " + emptyError);
    //console.log("minLengthError " + minLengthError);
    //console.log("maxLengthError " + maxLengthError);
    //console.log("priceError " + priceError);

    if (priceError || minLengthError || maxLengthError || emptyError) {
      setInputValid(false);
      validated(false);
    } else {
      setInputValid(true);
      validated(true);
    }
  }, [emptyError, minLengthError, maxLengthError, priceError]);

  return {
    emptyError,
    minLengthError,
    maxLengthError,
    priceError,
    errorMessage,
    inputValid,
  };
}

export { useValidation };
