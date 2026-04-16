import { Page } from '../../tools/types/page';
import { Result } from '../../tools/types/results/result';
import { mapToLocalArea, LocalArea } from './localArea';
import { LocalAreaBlank } from './localAreaBlank';
import { LocalAreaDetails, mapToLocalAreaDetails, mapToLocalAreaDetailsPage } from './localAreaDetails';

export class LocalAreasProvider {
	private static readonly headers: HeadersInit = [
		['X-Requested-With', 'XMLHttpRequest'],
		['Content-Type', 'application/json']
	];

	public static async saveLocalArea(localAreaBlank: LocalAreaBlank): Promise<Result> {
		const response = await fetch('/local_areas/save', {
			method: 'POST',
			headers: this.headers,
			body: JSON.stringify({...localAreaBlank, establishmentDate: localAreaBlank.establishmentDate?.toISOString().slice(0, 10)})
		});
		const json = await response.json();
		return Result.get(json);
	}

	public static async getLocalAreasPage(page: number, countInPage: number): Promise<Page<LocalAreaDetails>> {
		const response = await fetch(`/local_areas/get_page?page=${page}&countInPage=${countInPage}`, {
			method: 'GET',
			headers: this.headers
		});
		const json = await response.json();

		return mapToLocalAreaDetailsPage(json);
	}

	public static async getLocalAreaById(localAreaId: string): Promise<LocalArea | null> {
		const response = await fetch(`/local_areas/get_by_id?localAreaId=${localAreaId}`, {
			method: 'GET',
			headers: this.headers
		});
		const json = await response.json();

		return mapToLocalArea(json);
	}

	public static async markLocalAreaAsRemoved(localAreaId: string): Promise<Result> {
		const response = await fetch(`/local_areas/mark_as_removed?localAreaId=${localAreaId}`, {
			method: 'GET',
			headers: this.headers
		});
		const json = await response.json();

		return Result.get(json);
	}

	public static async getLocalAreaDetailsById(localAreaId: string): Promise<LocalAreaDetails | null> {
		const response = await fetch(`/local_areas/get_details_by_id?localAreaId=${localAreaId}`, {
			method: 'GET',
			headers: this.headers
		});
		const json = await response.json();

		return mapToLocalAreaDetails(json);
	}

	public static async EvaluateLocalAreaById(localAreaId: string): Promise<boolean | null> {
		const response = await fetch(`/local_areas/evaluate?localAreaId=${localAreaId}`, {
			method: 'GET',
			headers: this.headers
		});
		const json = await response.json();

		return json;
	}
}
