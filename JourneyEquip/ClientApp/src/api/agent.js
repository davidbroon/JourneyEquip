import axios from 'axios';

axios.defaults.baseURL = 'http:localhost:7065/api';

const responseBody = (response) => response.data;

const requests = {
	get: (url) => axios.get(url).then(responseBody),
	post: (url, body) => axios.post(url, body).then(responseBody),
	put: (url, body) => axios.put(url, body).then(responseBody),
	del: (url) => axios.delete(url).then(responseBody),
};

const RegisterInterest = {
	sendEmail: (data) => requests.post('/email/send', data),
};

const Agent = {
	RegisterInterest,
};

export default Agent;
