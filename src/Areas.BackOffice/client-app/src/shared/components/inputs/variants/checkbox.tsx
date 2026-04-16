import { Checkbox, Container } from "@mui/material";
import React, { ChangeEvent } from "react";
import { InputProps as DefaultProps } from "../input";

export interface Props extends DefaultProps {
  placeholder?: boolean;
  title?: string;

  value: boolean | null;
  onChange: (value: boolean | null) => void;

  isPassword?: boolean;
  required?: boolean;
}

export function CheckboxInput(props: Props) {
  function onChange(event: ChangeEvent<HTMLInputElement>) {
    let value: boolean | null = event.target.checked;

    props.onChange(value);
  }

  return (
    <Container
      sx={{
        padding: "0px 0px", 
        border: "1px solid rgba(0, 0, 0, 0.23)", 
        borderRadius: "4px", 
        position: "relative",
        display: "flex",
        alignItems: "center",

        "&:hover": {
          borderColor: "text.primary",
        },
      }}
    >
      <p style={{ margin: 0, padding: 0 }}>{props.title}</p>
      <Checkbox
        className={props.className}
        size={props.size}
        checked={props.value ?? false}
        onChange={onChange}
        required={props.required}
        disabled={props.disabled}
      />
    </Container>
  );
}
