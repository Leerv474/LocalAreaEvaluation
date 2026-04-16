import React from 'react';
import { Route } from 'react-router-dom';
import { RegionsPage } from './../regionPage';
import { RegionLink } from './regionLink';

export function RegionsRouter() {
	return (
		<>
			<Route path={RegionLink.index} element={<RegionsPage/>} />
		</>
	);
}
