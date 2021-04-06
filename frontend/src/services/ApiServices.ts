import Vue from 'vue'
import axios from 'axios'

const client = axios.create({
    baseURL: 'http://localhost:8501/v1/models/amazon_review',
    json: true,
})

export default {
    async execute(method, resource, data) {
        const accessToken = await Vue.prototype.$auth.getAccessToken()
        return client({
            method,
            url: resource,
            data
        }).then(req => {
            return req.data
        })
    },
    create(data) {
        return this.execute('post', ':predict', data)
    },
}