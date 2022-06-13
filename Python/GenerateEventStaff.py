import random

from GetSQLData import GetSQLDataStandard


def getUsersNotEventStaff(number):
    query = "SELECT * FROM getUsersNotEventStaff()"

    return random.sample(GetSQLDataStandard(query), number)


def getOrgs(number):
    query = "SELECT [name] FROM ORGANIZATION"

    return random.choices(random.choices(GetSQLDataStandard(query), k=int(number//1.5)), k=number)


roles = {'Event Manager': 1, 'Production crew': 2, 'Business Management': 3, 'Sales Management': 4,
         'Partnerships Manager': 4, 'Product Manager': 4, 'Marketing executive': 5, 'Admin': 6, 'Observer': 7,
         'Caster': 7, 'Sound dude': 8, 'Analyst': 8, 'Power dude': 8}


def generateRandomRole(number):
    return random.choices(list(roles.keys()), k=number)


def generateRandomEventStaff(number):
    event = []
    rolee = []
    users = getUsersNotEventStaff(number)
    orgs = getOrgs(number)
    roles1 = generateRandomRole(number)

    for i in range(0, number):
        eve = [users[i], orgs[i]]
        event.append(eve)
        evw = [users[i], roles1[i]]
        rolee.append(evw)

    super = []
    for i in range(0, number):
        for j in range(0, number):
            if orgs[i] == orgs[j] and roles[roles1[i]] < roles[roles1[j]]:
                super.append([users[i], users[j]])
                break

    return event, rolee, super

