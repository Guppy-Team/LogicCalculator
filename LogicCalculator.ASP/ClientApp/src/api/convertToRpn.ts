import axios, { AxiosError, AxiosResponse } from 'axios';

interface ConvertToRpnResponse {
  result?: string;
  error?: string;
}

export const convertToRpn = async (
  expression: string,
): Promise<ConvertToRpnResponse> => {
  try {
    const response: AxiosResponse<ConvertToRpnResponse> =
      await axios.post<ConvertToRpnResponse>('/api/ConvertToRpn', {
        expression,
      });
    return response.data;
  } catch (error: unknown) {
    if (axios.isAxiosError(error)) {
      const axiosError = error as AxiosError<ConvertToRpnResponse>;
      if (axiosError.response?.data) {
        return axiosError.response.data;
      } else {
        return { error: axiosError.message };
      }
    } else {
      return { error: (error as Error).message };
    }
  }
};
