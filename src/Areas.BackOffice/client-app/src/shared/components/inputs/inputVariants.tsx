import React from "react";
import { NumberInput, Props as NumberInputProps } from "./variants/numberInput";
import { Select, Props as SelectProps } from "./variants/select";
import {
  TextAreaInput,
  Props as TextAreaInputProps,
} from "./variants/textAreaInput";
import { TextInput, Props as TextInputProps } from "./variants/textInput";
import { DateInput, Props as DateInputProps } from "./variants/dateInput";
import { CheckboxInput, Props as CheckboxProps } from "./variants/checkbox";

type NumberInputVariant = { variant: "number" } & NumberInputProps;
type SelectVariant<T> = { variant: "select" } & SelectProps<T>;
type TextAreaInputVariant = { variant: "text-area" } & TextAreaInputProps;
type TextInputVariant = { variant: "text" } & TextInputProps;
type PasswordInputVariant = { variant: "password" } & TextInputProps;
type DateInputVariant = { variant: "date" } & DateInputProps;
type CheckboxVariant= { variant: "checkbox" } & CheckboxProps;

export type Props<T> =
  | TextInputVariant
  | TextAreaInputVariant
  | PasswordInputVariant
  | NumberInputVariant
  | DateInputVariant
  | CheckboxVariant
  | SelectVariant<T>;

export function InputVariants<T>(props: Props<T>) {
  switch (props.variant) {
    case "text":
      return <TextInput {...props} />;
    case "text-area":
      return <TextAreaInput {...props} />;
    case "password":
      return <TextInput {...props} isPassword />;
    case "number":
      return <NumberInput {...props} />;
    case "select":
      return <Select {...props} />;
    case "date":
      return <DateInput {...props} />;
    case "checkbox":
      return <CheckboxInput {... props} />;
  }
}
