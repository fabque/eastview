import { boot } from 'quasar/wrappers'
import axios from 'axios'

const apiPaths = {
  citizensPath: '/Citizens',
  tasksPath: '/Tasks',
  daysPath: 'Days',
  dayTodayPath: '/Days/today'
}
class HttpClient {
  constructor (axiosConfig) {
    this.instance = axios.create(axiosConfig)

    // TODO: Check if the axios issue was solved (axios ignores default params in requests)
    this.instance.interceptors.request.use(
      this._handleRequest.bind(this)
    )
  }
}

class API extends HttpClient {
  constructor (baseURL) {
    super({
      baseURL
    })
  }

  getCitizens () {
    const url = `${apiPaths.citizensPath}`
    return this.instance.get(url)
      .then((res) => {
        return res.data
      })
  }

  getTasks () {
    const url = `${apiPaths.tasksPath}`
    return this.instance.get(url)
      .then((res) => {
        return res.data
      })
  }

  getTasksByDay (day) {
    const url = `${apiPaths.tasksPath}`
    return this.instance.get(url)
      .then((res) => {
        return res.data
      })
  }

  getDays () {
    const url = `${apiPaths.daysPath}`
    return this.instance.get(url)
      .then((res) => {
        return res.data
      })
  }

  getDayToday () {
    const url = `${apiPaths.dayTodayPath}`
    return this.instance.get(url)
      .then((res) => {
        return res.data
      })
  }
}
//  set environment
export const baseURL = process.env.API_URL_BASE

// Export for testing
export const apiInstance = new API(baseURL)

export default boot(({ store }) => {
  store.$api = apiInstance
})
