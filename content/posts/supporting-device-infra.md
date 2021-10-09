---
title: Supporting Common Device Code, Infra, and Process
date: "2021-10-09"
draft: true
---

# Supporting Common Device Code, Infra, and Process

## Overview

As the teams that make up the Device side of the house we share common code, infrastructure, secret management, developer setup, threat modeling, architectual approaches, process, and expectations of excellence.

We also share the responsibility of making sure our common code follows best practices, is given the same level of scrutinity as our public facing services, and serves as an example of How To Write Awesome Code.

## Goals

- Identify a group of people dedicated to Device-wide support
- Members are 100% dedicated to enginnering excellence, care and feeding, priortizing
- Remove burdon on individuals
- Decentralize decisions while providing a consisent framework for discussion
- Prepare teams for NoOps approach to self-management

## Duties

- Able to handle bug fixes, code clean-up, security warnings
- Helps drive developer education, based on common issues
- Automatically included in all PRs as optional
- Looks broadly across all of Device for innovations
- Manages common libraries, pipelines, standards

## Work Item Breakdown

- Epic: Long-term Support of Common Code and Tooling
  - F.01 - Identify common/shared components
    - US.01 - `VWAC.Framework`
    - US.02 - `VWAC.Framework.Standards`
    - US.03 - Device orchastration pipelines
  - F.02 - Define upkeep expectations
  - F.03 - Define support/staffing model

### F.01 - Identify common/shared components

Identify common code, pipelines, dashboards, frameworks, infrastrcutre, etc. that should be considered common to all of Device.

- `VWAC.Framework`
- `VWAC.Framework.Standards`
- `VWAC.Framework.OpenApi`
- `Orchestration Pipelines`

### F.02 - Define upkeep expectations

- Dedicated to common code, infra, and tooling that benefits all teams
- Keep library dependencies up-to-date
- Notify teams of breaking changes (major version revs)
- Keep pipelines current with best practices
- Mediate changes, refactors, inclusions, splits
- Define, in concrete terms, what belongs in each common namespace
- Empower members/team to make impactful changes and decisons

### F.03 - Define support/staffing model

#### 1. Rotating Excellence Crew

- Every one to N sprints a member from each Device team focuses on best practices
- Guided by a rotating triad of engineering, architecture, and project management
- Members dedicated for at least two to four sprints

#### 2. Create a Dedicated Best Practices Team

