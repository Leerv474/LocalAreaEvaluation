import FunctionsIcon from '@mui/icons-material/Functions';

import { Button, IconButton, Tooltip } from '@mui/material';
import React from 'react';
import { ButtonProps as DefaultProps } from '../button';

export interface Props extends DefaultProps {}

export function ActionButton(props: Props) {
	switch (props.type) {
		case 'icon': {
			return (
				<Tooltip title={props.title ?? 'Действие'} disableHoverListener={props.disableHoverListener}>
					<IconButton
						color={props.color}
						size={props.size}
						sx={props.sx}
						className={props.className}
						onClick={props.onClick}
						disabled={props.disabled}>
						<FunctionsIcon color={props.color} fontSize={props.size} />
					</IconButton>
				</Tooltip>
			);
		}
		default: {
			return (
				<Button
					startIcon={<FunctionsIcon fontSize={props.size} color={props.color} />}
					variant={props.formVariant ?? 'outlined'}
					size={props.size}
					color={props.color}
					sx={props.sx}
					className={props.className}
					onClick={props.onClick}
					disabled={props.disabled}>
					{props.title ?? 'Действие'}
				</Button>
			);
		}
	}
}
