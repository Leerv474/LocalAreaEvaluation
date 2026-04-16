import { TextField } from "@mui/material";
import React, { ChangeEvent, useEffect, useState } from "react";
import { InputProps as DefaultProps } from "../input";

export interface Props extends DefaultProps {
  placeholder?: string;
  value: Date | null;
  onChange: (value: Date | null) => void;
  isPassword?: boolean;
  required?: boolean;
}

function formatDate(date: Date | null): string {
  if (!date) return "";
  if (typeof date === "string") {
    return date;
  }
  return date.toISOString().split("T")[0];
}

export function DateInput(props: Props) {
  const initialDate = formatDate(props.value);

  const [inputValue, setInputValue] = useState<string>(formatDate(props.value));

  useEffect(() => {
    const formatted = formatDate(props.value);
    setInputValue(formatted);
  }, [props.value]);

  function onChange(event: ChangeEvent<HTMLInputElement>) {
    const stringValue = event.target.value;
    setInputValue(stringValue);

    if (!stringValue) {
      props.onChange(null);
      return;
    }

    const dateValue = new Date(stringValue);

    if (!isNaN(dateValue.getTime())) {
      props.onChange(dateValue);
    } else {
      setInputValue(initialDate);
    }
  }

  return (
    <TextField
      type="date"
      label={props.title}
      placeholder={props.placeholder}
      className={props.className}
      size={props.size}
      slotProps={{
        inputLabel: { shrink: true },
      }}
      sx={props.sx}
      value={inputValue}
      onChange={onChange}
      required={props.required}
      disabled={props.disabled}
      fullWidth
    />
  );
}
